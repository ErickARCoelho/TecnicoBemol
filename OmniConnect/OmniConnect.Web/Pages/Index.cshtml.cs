using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OmniConnect.Web.Models;
using System.Text.Json;
using System.Text;

namespace OmniConnect.Web.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public UsuarioInputModel Usuario { get; set; } = new();

    public string? Mensagem { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        using var httpClient = new HttpClient();
        var json = JsonSerializer.Serialize(Usuario);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync("https://localhost:7147/api/usuarios", content);
            if (response.IsSuccessStatusCode)
                Mensagem = "Usuário cadastrado com sucesso!";
            else
                Mensagem = "Erro ao cadastrar: " + await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Mensagem = $"Erro ao conectar com a API: {ex.Message}";
        }

        return Page();
    }
}
