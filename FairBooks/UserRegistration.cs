using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FairBooks
{
    public class UserRegistration
    {
        SQLiteAsyncConnection connection;
        public String StatusMessage { get; set; }
        public UserRegistration(String dbPath){
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<User>();

          }
        public async Task AddNewUserAsync(String name, String pass)
        {
            int result = 0;
            try
            {
                result = await connection.InsertAsync(new User{ Name = name, Password = pass });
                StatusMessage=$"{result}{name}:ajout avec succes ";
            }
            catch(Exception ex)
            {
                StatusMessage = $"Impossible d'ajouter l'utilisateur:{name}\n Erreur:{ex:Message}";
            }

        }
        public async Task<List<User>> GetAllUserAsync()
        {
            try
            {
                return await connection.Table<User>().ToListAsync();
            }catch(Exception ex)
            {
                StatusMessage = $"impossible de récupérer la liste des utilisateur\n Erreur:{ex:Message}";
            }
            return new List<User>();
        }
        public async Task<int> UpdateUserAsync(User user)
        {
            int resultat = 0;
            try
            {
                resultat = await connection.UpdateAsync(user);
                StatusMessage = $"{resultat} utilisateur est mis à jour : {user.Name}";

                return resultat;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible de mettre à jour l'utilisateur.";
            }
            return resultat;
        }
    }
}
