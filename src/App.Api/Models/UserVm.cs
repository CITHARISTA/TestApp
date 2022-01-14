using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace App.Api.Models
{
    /// <summary>
    /// Модель представления данных о пользователе
    /// </summary>
    [Serializable]
    public class UserVm
    {
        /// <summary>
        /// Имя
        /// </summary>
        [JsonProperty("Name")]
        [Required(ErrorMessage = "Не укзано имя")]
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonProperty("lastName")]
        [Required(ErrorMessage = "Не укзана фамилия")]
        public string LastName { get; set; }
       
        /// <summary>
        /// Электронная почта
        /// </summary>
        [JsonProperty("email")]
        [Required(ErrorMessage = "Не укзана почта")]
        public string Email { get; set; }   

        /// <summary>
        /// Номер телефона
        /// </summary>
        [JsonProperty("phoneNumber")]
        [Required(ErrorMessage = "Не укзан номер телефона")]
        public string PhoneNumber { get; set; }
    }
}
