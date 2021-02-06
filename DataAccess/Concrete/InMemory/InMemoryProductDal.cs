using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        // class'ın içinde ama metodların dışında tanımlayınca global değişken oluyor. _ ile başlar
        List<Product> _products;

        // Constructor
        // Proje çalıştığı zaman constructor _products adında bir ürün listesi oluşturacak. ürün özellikleri de içinde.
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }
            };

        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product); ÇALIŞMAZ, YANLIŞ


            // İLK YOL: listeyi tek tek dolaşmak ve Id eşleşince o ürünü listeden kaldırmak.
            /*
            Product productToDelete = null;

            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }
            _products.Remove(productToDelete);
            */

            // LINQ kullanımı ile farklı bir yol | lambda => 
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);

            
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            // Parametre olarak gönderilen ürün id'sine sahip olan, listedeki ürünü bul
            // Açıklama: Parametre olarak ID=1 ve UnitPrice=500 özelliklerine sahip bir product
            // verdiğimizi varsayalım.
            // Kod sayesinde tüm ürünler listesinde ID=1 olan ürünü bulacağız. Bu ürüne productToDelete
            // adını vereceğiz. Bu ürünün veritabanında fiyatı 300. Fakat bizim parametremizdeki 
            // fiyat 500. Yani parametre ve veritabanındaki ürünün ID'leri aynı fakat fiyatı farklı.
            // "productToDelete.UnitPrice = product.UnitPrice" kodunu yazdığımız zaman,
            // verdiğimiz parametrenin fiyatı, productToUpdate'in yeni fiyatı olacak.
            // Böylece parametrede verdiğimiz nesnenin fiyatı, listedeki ürünün yeni fiyatı oldu.
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // parametre olarak verilen kategori ID 5 ise:
            // _products listesini gezecek ve kategori ID'si 5 olanları bir listeye koyup return edecek.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
