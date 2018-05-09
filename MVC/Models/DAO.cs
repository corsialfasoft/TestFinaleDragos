using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace MVC.Models {
    public interface IDAO { 
        void AddMenu(Menu menu);
        List<Menu> ListMenu();
        Menu ShowMenu(int id);
    }
    public class DAO : IDAO {

        private string GetConnection(){ 
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\MSSQLLocalDB";
            builder.InitialCatalog = "Ristorante";
            return builder.ToString();
        }
        public void AddMenu(Menu menu) {
            SqlConnection con = new SqlConnection(GetConnection());
            try{ 
                con.Open();
                SqlCommand cmd = new SqlCommand ("AddMenu",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@data",SqlDbType.DateTime).Value=menu.Data.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@pasto",SqlDbType.NVarChar).Value=menu.Pasto;
                cmd.Parameters.Add("@primo",SqlDbType.NVarChar).Value=menu.Primo;
                cmd.Parameters.Add("@secondo",SqlDbType.NVarChar).Value=menu.Secondo;
                cmd.Parameters.Add("@contorno",SqlDbType.NVarChar).Value=menu.Contorno;
                cmd.Parameters.Add("@dolce",SqlDbType.NVarChar).Value=menu.Dolce;
                int x = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if(x==0){ 
                    throw new Exception();    
                }
            }catch(Exception e){ 
                throw e;    
            }finally{
                con.Dispose();
            }
        }   

        public List<Menu> ListMenu() {
            SqlConnection con = new SqlConnection(GetConnection());
            try{ 
                con.Open();
                List<Menu> menus = new List<Menu>();
                SqlCommand cmd = new SqlCommand ("ListMenu",con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){ 
                    menus.Add(new Menu{Id=reader.GetInt32(0),Pasto=reader.GetString(1),Data=reader.GetDateTime(2)});    
                }
                reader.Close();
                cmd.Dispose();
                return menus;
            }catch(Exception e){ 
                throw e;    
            }finally{
                con.Dispose();
            }
        } 

        public Menu ShowMenu(int id) {
            SqlConnection con = new SqlConnection(GetConnection());
            try{ 
                con.Open();
                Menu menu = new Menu();
                SqlCommand cmd = new SqlCommand ("ShowMenu",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id",SqlDbType.Int).Value=id;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){ 
                    menu = new Menu{Id=reader.GetInt32(0),Primo=reader.GetString(1),Secondo=reader.GetString(2),Contorno=reader.GetString(3),Dolce=reader.GetString(4),Pasto=reader.GetString(5),Data=reader.GetDateTime(6)};    
                }
                reader.Close();
                cmd.Dispose();
                return menu;
            }catch(Exception e){ 
                throw e;    
            }finally{
                con.Dispose();
            }
        } 
    }
}