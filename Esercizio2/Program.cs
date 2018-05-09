using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio2 {
    class Program {/*
        static void Main(string[] args) {
            string frase = "Cia. non so cosa scrivere. ma devo fare, ripetizioni, ripetizioni, ripetizioni, cosa scrivedere devo";
            List<string> parole = new List<string>();
            List<string> pNumeri = new List<string>();
            string parola="";
            frase = frase.ToLower();
            for(int i = 0; i<frase.Length;i++){ 
                if(frase[i]>='a' && frase[i]<='z'){
                    parola = parola+frase[i];
                }else{
                    parole.Add(parola);
                    parola ="";
                }
            }
            foreach(string p in parole){ 
                int x = 0;
                foreach(string n in parole){ 
                    if(p.Equals(n)){ 
                        x++;    
                    }    
                }
                if(!p.Equals("")){ 
                    string daAdd = $"{p} --> {x}";
                    if(!pNumeri.Contains(daAdd)){ 
                        pNumeri.Add(daAdd);   
                    }
                }
            }
            foreach(string t in pNumeri){ 
                Console.WriteLine(t);    
            }
        }*/
    }
}
