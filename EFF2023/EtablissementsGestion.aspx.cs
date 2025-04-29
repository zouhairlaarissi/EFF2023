using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace EFF2023
{
    public partial class EtablissementsGestion : System.Web.UI.Page
    {
        public string conn = "Data Source=DESKTOP-0744EKU;Initial Catalog=EFF2024;Integrated Security=True";

        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();

        private void Afficher()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Etablissements", con);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                AfficherMessage($"Erreur: {ex.Message}", "error");
            }
        }




        private void ViderChamps()
        {
            txtCode.Text = "";
            txtNom.Text = "";
            txtVille.Text = "";
            lblMessage.Text = "";
            Afficher()
        }

        private void AfficherMessage(string message, string type)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = $"text-{type}";
        }


        public void Ajouter(Etablissement etab)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtVille.Text))
            {
                AfficherMessage("Tous les champs doivent être remplis.", "warning");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Etablissements VALUES(@code, @nom, @ville)", con);
                    cmd.Parameters.AddWithValue("@code", etab.Code);
                    cmd.Parameters.AddWithValue("@nom", etab.Nom);
                    cmd.Parameters.AddWithValue("@ville", etab.Ville);
                    cmd.ExecuteNonQuery();

                    AfficherMessage("Établissement ajouté avec succès", "success");
                    Afficher();

                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                AfficherMessage("Ce code existe déjà!", "error");
            }
            catch (Exception ex)
            {
                AfficherMessage($"Erreur: {ex.Message}", "error");
            }
        }

        public void Supprimer(int code)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                AfficherMessage("Un code doit être fourni.", "warning");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Etablissements WHERE Code=@code", con);
                    cmd.Parameters.AddWithValue("@code", code);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        AfficherMessage("Établissement supprimé avec succès", "success");
                    }
                    else
                    {
                        AfficherMessage("Aucun établissement trouvé avec ce code", "warning");
                    }

                    Afficher();

                }
            }
            catch (Exception ex)
            {
                AfficherMessage($"Erreur: {ex.Message}", "error");
            }
        }


        public Etablissement Chercher(int code)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                AfficherMessage("Un code doit être fourni.", "warning");
                return null;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Etablissements WHERE Code=@code", con);
                    cmd.Parameters.AddWithValue("@code", code);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())

                        {
                            return new Etablissement(
                                Convert.ToInt32(dr["Code"]),
                                dr["Nom"].ToString(),
                                dr["Ville"].ToString());

                        }
                        else
                        {
                            AfficherMessage("Aucun établissement trouvé avec ce code", "warning");
                            return null;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                AfficherMessage($"Erreur: {ex.Message}", "error");
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Afficher();


            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                AfficherMessage("Le code est obligatoire", "error");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                AfficherMessage("Le nom est obligatoire", "error");
                return;
            }

            // Conversion sécurisée du code
            if (!int.TryParse(txtCode.Text, out int code))
            {
                AfficherMessage("Le code doit être un nombre valide", "error");
                return;
            }

            Etablissement etab = new Etablissement(code, txtNom.Text, txtVille.Text);
            Ajouter(etab);
            Afficher();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                AfficherMessage("Veuillez entrer un code à supprimer", "error");
                return;
            }

            // Conversion sécurisée du code
            if (!int.TryParse(txtCode.Text, out int code))
            {
                AfficherMessage("Le code doit être un nombre valide", "error");
                return;
            }

            Supprimer(code);

            Afficher();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            // Validation du champ code
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                AfficherMessage("Veuillez entrer un code à rechercher", "error");
                return;
            }

            // Conversion sécurisée du code
            if (!int.TryParse(txtCode.Text, out int code))
            {
                AfficherMessage("Le code doit être un nombre valide", "error");
                return;
            }

            Etablissement etab = Chercher(code);
            if (etab != null)
            {
                txtNom.Text = etab.Nom;
                txtVille.Text = etab.Ville;
                AfficherMessage("Établissement trouvé", "success");
            }
            else
            {
                ViderChamps();
                AfficherMessage("Aucun établissement trouvé avec ce code", "warning");

            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            ViderChamps();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("~/default.html")))
            {
                Response.Redirect("~/default.html");
            }
            else
            {
                lblMessage.Text = "La page default.html n'a pas été trouvée";
            }
        }
    }
}
