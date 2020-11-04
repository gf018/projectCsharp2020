using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;

namespace WindowsFormsApp3{//www.youtube.com/watch?v=g6etQnX-BQY       001. C#.NET Read Write Registry Key
    public partial class Form1 : Form{

        static RegistryKey folderPath = Registry.CurrentUser;
        static string subFolderPath = "Prueba";
        static RegistryKey regKey = folderPath;
        static RegistryKey subKey = regKey.CreateSubKey(subFolderPath);
        /*static string keyValueRe = "resolucion";
        static string keyValueK1 = "tecla key1";
        static string keyValueK2 = "tecla key2";
        static string keyValueCal = "tecla Calidad imagen";
        static string keyValueAmb = "tecla Ambientacion";
        static string keyValuePant = "tecla Pantalla";*/                //static Hashtable sett = new Hashtable();
        public Form1(){
            InitializeComponent();
        }
           private void Button1_Click(object sender, EventArgs e){// botón cancelar    link útil aunq este en otro lenguaje www.youtube.com/watch?v=hRWw1rK1LMQ     VBScript Basics, Part 59 | Delete items in the registry (Regedit)
            regKey.DeleteSubKey("Prueba2");     //RegistryKey subKey = regKey.OpenSubKey("Prueba2");                //subKey.DeleteSubKeyTree(keyValue);
        }
        private void Button2_Click(object sender, EventArgs e){ //botón guardar   OJO Q AL CORREGIR MINÚS X MAYÚS EN ESTE MÉTODO, EN Form1.Designer.cs EN private void InitializeComponent(){ ->     //button2      TENGO Q AGREGAR EN ÚLTIMA LÍNEA ESTO!!!!!!!! ->   this.button2.Click += new System.EventHandler(this.Button2_Click);       TENGO Q MODIFICAR en this. -> b X B !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Add(comboBox1.Text.ToString(), 0, RegistryValueKind.DWord); // al usar dword, en 2º parámetro tiene q ir valor hexadecimal   !!!!!!!!!!!!!!!!!!!!
            Add(comboBox2.Text.ToString(), 0, RegistryValueKind.DWord);
            Add(comboBox3.Text.ToString(), 0, RegistryValueKind.DWord);
            Add(comboBox4.Text.ToString(), 0, RegistryValueKind.DWord);
            if (radioButton1.Text.ToString()== "Sí") // usar if p' saber cuál opción eligió   
                Add(radioButton1.Text.ToString(), 0, RegistryValueKind.DWord);
            else
                Add(radioButton2.Text.ToString(), 0, RegistryValueKind.DWord);
            if (radioButton3.Text.ToString()== "Completa")
                Add(radioButton3.Text.ToString(), 0, RegistryValueKind.DWord);
            else
                Add(radioButton4.Text.ToString(), 0, RegistryValueKind.DWord);                //RegistryKey regKey = folderPath;                  //RegistryKey subKey = regKey.OpenSubKey(subFolderPath);                    /*foreach (string key in sett.Keys)                Console.WriteLine($"llave {key}, valor {sett[key]}");*///subKey.SetValue(key, sett[key]);
            MessageBox.Show(comboBox1.Text); MessageBox.Show(comboBox2.Text);
        }
        public static void Add(string setting, int valor, RegistryValueKind tipo){ //www.stackoverflow.com/questions/43204497/c-sharp-registry-subkey-dword-value		// crear diccionario q en c/ key guarde setting y en valor guarde opción elegida
            subKey.SetValue(setting, valor, tipo);                  //for (int i = 0; i < 3; i++){                    //sett.Add(setting, opc);
         }

        /*private class modoVentana : registro{

            public string estadoVentana(){
                return leerRegistro("WindowMode");
            }
        }*/

          protected string leerRegistro(string clave){
            RegistryKey subKey = regKey.OpenSubKey(subFolderPath);
            int resultados = (Int32)subKey.GetValue(clave);
            return resultados.ToString();
          }

        /*private class registro{
            protected void modificarRegistro(string clave, int valor, RegistryValueKind tipo){
                RegistryKey regKey = folderPath;
                RegistryKey subKey = regKey.OpenSubKey(subFolderPath);
                subKey.SetValue(clave, valor, tipo);
            }

            private class resolucion : registro{
                public void _640x480(){
                    modificarRegistro("Resolution", 0, RegistryValueKind.DWord);
            }
        }*/
    }
}
