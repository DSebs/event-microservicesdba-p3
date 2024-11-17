package com.lausebscode.controlador;

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
    public ResponseEntity<Organizador> buscarOrganizadorId(@PathVariable int id) {
        try {
            Organizador organizador = organizadorServicio.buscarPorId(id);
            return ResponseEntity.ok(organizador);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @GetMapping("/buscar/nombre/{nombre}")
    public ResponseEntity<Organizador> buscarOrganizadorNombre(@PathVariable String nombre) {
        try {
            Organizador organizador = organizadorServicio.buscarPorNombre(nombre);
            return ResponseEntity.ok(organizador);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/eliminar")
    public ResponseEntity<Void> eliminarOrganizador(@RequestBody Organizador organizador) {
        try {
            organizadorServicio.eliminarOrganizador(organizador);
            return ResponseEntity.noContent().build();
        } catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/listar")
    public ResponseEntity<List<Organizador>> listarTodosLosOrganizadores() {
        List<Organizador> organizadores = organizadorServicio.listarTodosLosOrganizadores();
        return ResponseEntity.ok(organizadores);
    }

    @GetMapping("/listar/inicial/{inicial}")
    public ResponseEntity<List<Organizador>> listarOrganizadoresPorInicial(@PathVariable String inicial) {
        try {
            List<Organizador> organizadores = organizadorServicio.listarOrganizadoresPorInicial(inicial);
            return ResponseEntity.ok(organizadores);
        } catch (IllegalArgumentException e) {
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