using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Validations;

namespace WebApiAutores.Entidades
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        //[PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        //[Range(18, 120)]
        //[NotMapped] // Permite que las propiedades no correspondan a una columna de la tabla correspondiente en  DB 
        //public int Edad { get; set; }
        //[CreditCard] //Valida que el nro de la tarjeta sea correcto
        //[NotMapped]
        //public string TarjetaDeCredito { get; set; }
        //[Url]
        //[NotMapped]
        //public string URL { get; set; }

        //public int Menor { get; set; }
        //public int Mayor { get; set; }
        public List<Libro> Libros { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayus", new string[] { nameof(Nombre) });
                }

                //if (Menor > Mayor)
                //{
                //    yield return new ValidationResult("Este valor no puede ser mas grande al campo mayor", new string[] { nameof(Menor) });
                //}
            }
        }
    }
}
