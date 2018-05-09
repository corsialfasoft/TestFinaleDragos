using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {
    public class Menu{ 
        public int Id{ get;set;}
        public DateTime Data{ get;set;}
        public string Pasto{get;set;}
        public string Primo{get;set;}
        public string Secondo{ get;set;}
        public string Contorno { get;set;}
        public string Dolce{ get;set;}
    }

    public interface IDataModel { 
        void AddMenu(Menu menu);
        List<Menu> ListMenu();
        Menu ShowMenu(int id);
    }
    public class DataModel : IDataModel {
        DAO d = new DAO();
        public void AddMenu(Menu menu) {
            d.AddMenu(menu);
        }

        public List<Menu> ListMenu() {
            return d.ListMenu();
        }

        public Menu ShowMenu(int id) {
            return d.ShowMenu(id);
        }
    }
}