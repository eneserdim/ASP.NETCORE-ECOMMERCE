using EEducation.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Core.Service
{
    // T ifadesi Generic bir ifadedir.
    // where T : CoreEntity bu kodu yazarak T Generic ifadesinin bir CoreEntity sınıfı olması gerektiğini belirttik.
    // where T : CoreEntity ifadesi bir C# Constraints(Kısıtlayıcılar) yazım örneğidir
    // Generic Model: Generic ifadesinin kullanımı ile herhangi bir model(tablo-sınıf) için çalışabileceğini belirtir.
    public interface IDbService<T> where T : CoreEntity
    {
        // Ekleme metodunu T generic ifadesini kullanarak bütün tablolara kayıt atabilecek şekilde tanımladık
        bool Add(T item);

        // Update metodunu T generic ifadesini kullanarak bütün tablolara güncelleyebilecek  şekilde tanımladık
        bool Update(T item);

        // Silme metodunu T generic ifadesini kullanarak bütün tablolara silebilecek şekilde tanımladık
        bool Delete(T item);

        // Liste Getir metodunu kullanarak istediğimiz bir tablonun bütün içeriğini liste olarak okuyabileceğiz
        List<T> GetAll();

        // Id ye göre kayıt getir
        T GetById(int id);

        //List<T> GetAllByIdCategory();

        // Kayıt edilmesi
        bool Save();
    }
}
