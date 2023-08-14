using HospitalCrud.Entity;

namespace HospitalCrud.Service.interfaces
{
    public interface IPacienteService
    {
        Task<int> CriarFichaPaciente(Paciente paciente, string base84);
        Task DeletarFichaPaciente(int id);
        Task<Paciente> ObterFichaPorId(int id);
        Task<List<Paciente>> ListarFichasPacientes();
        Task AtualizarFichaPaciente(Paciente paciente, string base84);
    }
}
