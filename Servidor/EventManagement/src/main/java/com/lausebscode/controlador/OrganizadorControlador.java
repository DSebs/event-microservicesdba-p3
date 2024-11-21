package com.lausebscode.controlador;

import com.lausebscode.dto.OrganizadorDTO;
import com.lausebscode.modelo.Organizador;
import com.lausebscode.servicio.OrganizadorServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/organizador")
public class OrganizadorControlador {

    @Autowired
    private OrganizadorServicio organizadorServicio;

    @PostMapping("/crear")
    public ResponseEntity<Organizador> crearOrganizador(@RequestBody Organizador organizador) {
        try {
            Organizador organizadorCreado = organizadorServicio.crearOrganizador(organizador);
            return ResponseEntity.status(HttpStatus.CREATED).body(organizadorCreado);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/buscar/{id}")
    public ResponseEntity<OrganizadorDTO> buscarOrganizadorId(@PathVariable int id) {
        try {
            OrganizadorDTO dto = organizadorServicio.buscarPorIdDTO(id);
            return ResponseEntity.ok(dto);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @GetMapping("/buscar/nombre/{nombre}")
    public ResponseEntity<OrganizadorDTO> buscarOrganizadorPorNombre(@PathVariable String nombre) {
        try {
            OrganizadorDTO dto = organizadorServicio.buscarPorNombreDTO(nombre);
            return ResponseEntity.ok(dto);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/eliminar/{id}")
    public ResponseEntity<Void> eliminarOrganizador(@PathVariable int id) {
        try {
            organizadorServicio.eliminarOrganizadorPorId(id);
            return ResponseEntity.noContent().build();
        } catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/listar")
    public ResponseEntity<List<OrganizadorDTO>> listarTodosLosOrganizadores() {
        try {
            List<OrganizadorDTO> organizadores = organizadorServicio.listarTodosLosOrganizadoresDTO();
            return ResponseEntity.ok(organizadores);
        }catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/listar/inicial/{inicial}")
    public ResponseEntity<List<OrganizadorDTO>> listarOrganizadoresPorInicial(@PathVariable String inicial) {
        try {
            List<OrganizadorDTO> organizadores = organizadorServicio.listarOrganizadoresInicial(inicial);
            return ResponseEntity.ok(organizadores);
        }catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @PutMapping("/{id}")
    public ResponseEntity<Organizador> actualizarOrganizador(
            @PathVariable("id") int id,
            @RequestBody Organizador nuevoOrganizador) {
        try {
            Organizador organizadorActualizado = organizadorServicio.actualizarOrganizador(id, nuevoOrganizador);
            return ResponseEntity.ok(organizadorActualizado);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping("/{organizadorId}/asignar-feria/{feriaId}")
    public ResponseEntity<Organizador> asignarFeriaGastro(
            @PathVariable int organizadorId,
            @PathVariable int feriaId) {
        try {
            Organizador organizadorActualizado = organizadorServicio.asignarFeriaGastro(organizadorId, feriaId);
            return ResponseEntity.ok(organizadorActualizado);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }
}