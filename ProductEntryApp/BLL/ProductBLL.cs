using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntryApp.DLL.DAO;
using ProductEntryApp.DLL.GATEWAY;

namespace ProductEntryApp.BLL
{
    class ProductBLL
    {
        private ProductGateway aProductGateway;

        public string Save(Product aProduct)
        {
            aProductGateway = new ProductGateway();

          
            if (CheckLetterOfCode(aProduct))
            {
                return "code character must be three";
            }
            if (CheckLetterOfName(aProduct))
            {
                return "Name character must be between 5 to 10 characters";
            }
            string msg = aProductGateway.Save(aProduct);
            return msg;

        }

        private bool CheckLetterOfName(Product aProduct)
        {
            int numberOfLetters = 0;
            foreach (char letter in aProduct.Name)
            {
                
                    numberOfLetters++;
                   
                             
            }
            if (numberOfLetters < 5 || numberOfLetters > 10)
                return true;
            return false;
            
            
        }

        private bool CheckLetterOfCode(Product aProduct)
        {
            int numberOfLettersCode = 0;
            foreach (char letter in aProduct.ProductCode)
            {

                numberOfLettersCode++;

            }
            if (numberOfLettersCode != 3)
                return true;
            return false;
           

           
        }


        public List<Product> GetAllProductList()
        {
            aProductGateway = new ProductGateway();
            return aProductGateway.GetAllProduct();
        }
    }
}
