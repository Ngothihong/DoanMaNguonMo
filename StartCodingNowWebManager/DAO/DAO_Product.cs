using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using Sakura.AspNetCore;
using StartCodingNowWebManager.ApiCommunicationTools;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.DAO
{
    public class DAO_Product
    {
       // private QL_SCN db = new QL_SCN();
        public  IEnumerable<ProductModel> listpd(int page, int pagesize)
        {
            var data= new List<ProductModel>();
            try
            {
               data = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                if (data != null) return data.OrderByDescending(x => x.Idrobot).ToPagedList(pagesize, page);
                else return null;
            }
            catch
            {
                return null;
            }
            
            
        }
        public ProductModel ViewDetail(string ID)
        {
            var data = new List<ProductModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                if (data != null) return data.Where(x => x.Idrobot == ID).SingleOrDefault();
                else return null;
            }
            catch
            {
                return null;
            }

           
        }

        public IEnumerable<ProductModel> search(string tk, int page, int pagesize)
        {
            var data = new List<ProductModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                if (data != null) return data.Where(x => x.Idrobot.Contains(tk) || x.Name.Contains(tk)).OrderByDescending(x => x.Idrobot).ToPagedList(pagesize, page);
                else return null;
            }
            catch
            {
                return null;
            }

        }

        public IEnumerable<ProductModel> top3_pd()
        {

            var data = new List<ProductModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                if (data != null) return data.Take(3).ToList();
                else return null;
            }
            catch
            {
                return null;
            }
           
        }

        public bool Update(ProductModel pd)
        {

            var data = new List<ProductModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                if (data != null)
                {
                    var up = data.SingleOrDefault(x => x.Idrobot == pd.Idrobot);
                    if (up != null)
                    {
                        up.Name = pd.Name;
                        up.Image = pd.Image;
                        up.Number = pd.Number;
                        up.Price = pd.Price;
                        up.State = pd.State;

                        var temp = ApiClientFactory.ThanhDatInstance.UpdateProduct(up);                      
                        return temp.IsSuccess;

                    }
                    return false;
                }
                else
                {
                    return false;
                }

               


            }
            catch
            {
                return false;
            }

           
        }

    }
}