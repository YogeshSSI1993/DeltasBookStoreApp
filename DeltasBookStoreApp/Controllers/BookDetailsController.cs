using DeltasBookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DeltasBookStoreApp.Controllers
{
    public class BookDetailsController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5110/api");
        private readonly HttpClient _httpClient;

        public BookDetailsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<BookDetails>? booksList = new List<BookDetails>();
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/BookDetails").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string Data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                booksList = JsonConvert.DeserializeObject<List<BookDetails>>(Data);
            }

            return View(booksList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDetails bookDetails)
        {
            try
            {
                string Data = JsonConvert.SerializeObject(bookDetails);
                StringContent content = new StringContent(Data, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(_httpClient.BaseAddress + "/BookDetails", content).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Book Details Added.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Saving, Please try again later.";
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            BookDetails? bookDetails = new BookDetails();
            try
            {
                HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/BookDetails/" + Id).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string Data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    bookDetails = JsonConvert.DeserializeObject<BookDetails>(Data);
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Fetching, Please try again later.";
                return View();
            }
            return View(bookDetails);
        }

        [HttpPost]
        public IActionResult Edit(BookDetails bookDetails)
        {
            try
            {
                string Data = JsonConvert.SerializeObject(bookDetails);
                StringContent content = new StringContent(Data, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = _httpClient.PutAsync(_httpClient.BaseAddress + "/BookDetails/" + bookDetails.Id, content).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Book Details Updated.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Updating, Please try again later.";
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            BookDetails? bookDetails = new BookDetails();
            try
            {
                HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/BookDetails/" + Id).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string Data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    bookDetails = JsonConvert.DeserializeObject<BookDetails>(Data);
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Fetching, Please try again later.";
                return View();
            }
            return View(bookDetails);
        }

        [HttpPost]
        public IActionResult Delete(BookDetails bookDetails)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/BookDetails/" + bookDetails.Id).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Book Details Deleted.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Updating, Please try again later.";
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult DeletedBooks()
        {
            List<BookDetails>? booksList = new List<BookDetails>();
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/BookDetails/GetDeletedBookDetails").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string Data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                booksList = JsonConvert.DeserializeObject<List<BookDetails>>(Data);
            }

            return View(booksList);
        }
    }
}
