using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelloWorldApi.Models;

namespace HelloWorldApi.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        public Product PostProduct(Product item)
        {
            item = repository.Add(item);
            return item;
        }

        //public HttpResponseMessage PostProduct(Product item)
        //{
        //    item = repository.Add(item);
        //    var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

        //    //string uri = Url.Link("DefaultApi0", new { id = item.Id });
        //    string uri = Url.Link("DefaultApi10", item);
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}

        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
