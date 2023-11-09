using System.Security.Cryptography;
using System.Text;
using System;
using System.Web.Mvc;
using voluntariado2.Models;
using System.Data.SqlClient;
using System.Data;


namespace voluntariado2.Controllers
{
    public class UsersController : Controller
    {

        static string cadena = "Data source=LV310;Initial Catalog=Voluntariado;Integrated Security=true";

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        //Get: Register
        public ActionResult Register()
        {
            
            return View(User);
        }

        //Get: Register
        public ActionResult RegisterOferror()
        {

            return View(User);
        }

        //Get: Login
        public ActionResult Login()
        {
            
            return View(User);
        }

        //post Register
        [HttpPost]
        public ActionResult Register(UserModel OUsuario) {
            bool registrado;
            string Mensaje;

            if(OUsuario.Password == OUsuario.ConfirmPassword)
            {
                OUsuario.Password = convertSha256(OUsuario.Password);
            }
            else{
                ViewData["Mensaje"] = "Las contraseñas no coinciden.";
                return View();
            }
            using (SqlConnection cn = new SqlConnection(cadena)) {
                SqlCommand cmd = new SqlCommand("sp_RegisterUser",cn);
                cmd.Parameters.AddWithValue("Username", OUsuario.UserName);
                cmd.Parameters.AddWithValue("password", OUsuario.Password);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            ViewData["Mensaje"] = Mensaje;
            if (registrado)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Login(UserModel OUsuario)
        {
            OUsuario.Password = convertSha256(OUsuario.Password);

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidateUser", cn);
                cmd.Parameters.AddWithValue("Username", OUsuario.UserName);
                cmd.Parameters.AddWithValue("password", OUsuario.Password);
     
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                OUsuario.IdUser = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                
            }
            if(OUsuario.IdUser != 0)
            {
                Session["usuario"] = OUsuario;
                
                return RedirectToAction("UserRegisterOferror", "Interfaces");

            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View(User);
            }          
        }


        public static string convertSha256(string text)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result )
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
        /*public static string EncryptAES(string plainText, string key, string iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }*/


    }
}