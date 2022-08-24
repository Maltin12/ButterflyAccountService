using Butterfly.Account.Common.Extensions;
using Butterfly.Account.Domain.Entities;
using Butterfly.Account.Persistence;

namespace visionagency.Butterfly.Account.Persistence
{
    /// <summary>
    /// Account db initializer is a class the serves only once, on the first start up of the project. 
    /// </summary>
    public class AccountDbInitializer
    {
        /// <summary>
        /// Initalize method is a static one which is the trigger for seeding database.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(AccountDbContext context)
        {
            new AccountDbInitializer().Seed(context);
        }
        /// <summary>
        /// The purpose of the Seed method is to centralize all other specific seeding methods. 
        /// </summary>
        /// <param name="context">Project database context.</param>
        private void Seed(AccountDbContext context)
        {
            SeedGenders(context);
            SeedDepartments(context);
            SeedEmailTemplates(context);
            SeedSuperUser(context);
            SeedNationalities(context);
            SeedCountries(context);
            SeedCities(context);
           

        }
        /// <summary>
        /// Seed email templates method serves for seeding the email templates which will be used for sending to user.
        /// </summary>
        /// <param name="context">Databse context of the project</param>
        private void SeedEmailTemplates(AccountDbContext context)
        {
            var emailTemplates = ReadJson("email-templates.json").Deserialize<IList<EmailTemplate>>();

            var newTemplates = emailTemplates.Where(json => !context.EmailTemplates.Select(db => db.Id).Contains(json.Id)).ToList();

            if (newTemplates.Count() == 0) return;

            context.EmailTemplates.AddRange(newTemplates);
            context.SaveChanges();
        }

        public void SeedGenders(AccountDbContext context)
        {
            if (context.Genders.Any()) return;

            var genders = ReadJson("genders.json").Deserialize<IList<Gender>>();

            context.Genders.AddRange(genders);

            context.SaveChanges();
        }
        public void SeedDepartments(AccountDbContext context)
        {
            if (context.Departments.Any()) return;

            var departments = ReadJson("departments.json").Deserialize<IList<Department>>();

            context.Departments.AddRange(departments);

            context.SaveChanges();
        }

        /// <summary>
        /// Seed super user serves for registering the first user when system come to life.
        /// </summary>
        /// <param name="context">The Database context of the project</param>
        private void SeedSuperUser(AccountDbContext context)
        {
            if (context.Users.Any()) return;

            var user = ReadJson("user.json").Deserialize<User>();
            context.Users.Add(user);
            context.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void SeedNationalities(AccountDbContext context)
        {
            if (context.Nationalities.Any()) return;

            var nationalities = ReadJson("nationalities.json").Deserialize<IList<Nationality>>();

            context.Nationalities.AddRange(nationalities);
            
            context.SaveChanges();
        }

        public void SeedCountries(AccountDbContext context)
        {
            if (context.Countries.Any()) return;

            var countries = ReadJson("countries.json").Deserialize<IList<Country>>();

            context.Countries.AddRange(countries);

            context.SaveChanges();
        }

        public void SeedCities(AccountDbContext context)
        {
            if (context.Cities.Any()) return;

            var cities = ReadJson("cities.json").Deserialize<IList<City>>();

            context.Cities.AddRange(cities);

            context.SaveChanges();
        }
        #region Read Json Method
        /// <summary>
        /// Read Json Method serves for reading json file for seeding purpose. 
        /// </summary>
        /// <param name="fileName">The file name of the seeding json</param>
        /// <returns>A string which contains result got from json file</returns>
        private string ReadJson(string fileName)
        {
            var assembly = typeof(AccountDbContext).Assembly;

            var resources = assembly.GetManifestResourceNames();

            using (Stream stream = assembly.GetManifestResourceStream(resources.First(x => x.Contains(fileName))))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    return result;
                }
            }
        }
        #endregion

        
    }
}
