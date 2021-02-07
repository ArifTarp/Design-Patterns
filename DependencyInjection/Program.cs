using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            // we used ninject
            IKernel kernel = new StandardKernel();

            kernel.Bind<IProductDal>().To<NhProductDal>().InSingletonScope();
            kernel.Bind<IProductService>().To<ProductManager>().InSingletonScope();

            var productManager = kernel.Get<IProductService>();

            productManager.Save();

            Console.ReadLine();
        }
    }

    class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            _productDal.Save();
        }
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved With Ef");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved With Nh");
        }
    }

    interface IProductService
    {
        void Save();
    }

    interface IProductDal
    {
        void Save();
    }
}
