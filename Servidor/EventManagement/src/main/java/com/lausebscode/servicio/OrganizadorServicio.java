package com.lausebscode.servicio;

import com.lausebscode.dto.OrganizadorDTO;
import com.lausebscode.modelo.Organizador;
import java.util.List;

public interface OrganizadorServicio {
    Organizador crearOrganizador(Organizador organizador);
    Organizador buscarPorId(int id);
    Organizador buscarPorNombre(String nombre);
    void eliminarOrganizador(Organizador organizador);
    List<Organizador> listarTodosLosOrganizadores();
    List<Organizador> listarOrganizadoresPorInicial(String inicial);
    Organizador actualizarOrganizador(int id, Organizador organizador);
    Organizador asignarFeriaGastro(int organizadorId, int feriaGastroId);

    // Metodos que retornan DTO ----------------

    OrganizadorDTO buscarPorIdDTO(int id);
    OrganizadorDTO buscarPorNombreDTO(String nombre);
    List<OrganizadorDTO> listarTodosLosOrganizadoresDTO();
    void eliminarOrganizadorPorId(int id);
    List<OrganizadorDTO> listarOrganizadoresInicial(String inicial);


}