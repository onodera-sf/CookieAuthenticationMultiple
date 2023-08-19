using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookieAuthenticationMultipleMvc.Models
{
  public class LoginModel
  {
    /// <summary>���[�U�[���B</summary>
    [Required]
    [DisplayName("���[�U�[��")]
    public string UserName { get; set; } = "";

    /// <summary>�p�X���[�h�B</summary>
    [Required]
    [DataType(DataType.Password)]
    [DisplayName("�p�X���[�h")]
    public string Password { get; set; } = "";
  }
}