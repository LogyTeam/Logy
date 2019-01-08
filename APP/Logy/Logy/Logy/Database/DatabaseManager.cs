using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;
using Realms;
using Logy.Logbook;
using System.Linq;
using Xamarin.Forms;
using Realms.Exceptions;


namespace Logy.Database
{
    /// <summary>
    /// Class used for Database interaction
    /// </summary>
    class DatabaseManager
    {

        /// <summary>
        /// Connection to the database
        /// </summary>
        /// <returns></returns>
        public static Realm GetDB()
        {
            var config = new RealmConfiguration("Logy.realm");
            Realm realm;

            try
            {
                realm = Realm.GetInstance(config);

                return realm;
            }
            catch (RealmMigrationNeededException r)
            {
                Realm.DeleteRealm(config);
                realm = Realm.GetInstance(config);

                return realm;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Send a select query to the SQLiteDatabase
        /// </summary>
        /// <param name="query"></param>s
        /// <returns></returns>
        public static List<T> Select<T>(Func<T, bool> query) where T : RealmObject
        {
            Realm realm = GetDB();

            List<T> results = realm.All<T>().Where(query).ToList();

            return results;
        }

        /// <summary>
        /// Send a select query to the SQLiteDatabase
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Select<T>() where T : RealmObject
        {
            Realm realm = GetDB();

            List<T> results = realm.All<T>().ToList();

            return results;
        }

        /// <summary>
        /// Add entry in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Insert<T>(T obj) where T : RealmObject
        {
            Realm realm = GetDB();

            realm.Write(() =>
            {                
                realm.Add(obj);          
            });
        }

        /// <summary>
        /// Add entry in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objects"></param>
        public static void Insert<T>(List<T> objects) where T : RealmObject
        {
            Realm realm = GetDB();

            realm.Write(() =>
            {
                foreach (T o in objects)
                {
                    realm.Add(o);
                }
            });
        }
    }
}
