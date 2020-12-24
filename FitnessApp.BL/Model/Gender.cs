using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    ///  Пол
    /// </summary>
    public class Gender
    {
        /// <summary>
        ///  Название
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="_name"> Название пола </param>
        public Gender(string _name)
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(_name));
            }

            Name = _name;
        }
        /// <summary>
        /// Переоределение
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
