import React, { useState } from 'react';
import { eliminarOrganizador, buscarOrganizadorPorId } from '../../services/organizadorService';

const EliminarOrganizador = () => {
  const [id, setId] = useState('');
  const [organizador, setOrganizador] = useState(null);
  const [eliminado, setEliminado] = useState(false);

  // Manejador para buscar el organizador por ID
  const handleBuscar = async (e) => {
    e.preventDefault();
    try {
      const resultado = await buscarOrganizadorPorId(id);
      setOrganizador(resultado);
      setEliminado(false); // Reinicia el estado de eliminación
    } catch (error) {
      alert('Error al buscar organizador: ' + error.message);
    }
  };

  // Manejador para eliminar el organizador
  const handleEliminar = async () => {
    try {
      await eliminarOrganizador(id); // Elimina el organizador por ID
      setEliminado(true); // Indica que la eliminación fue exitosa
      setOrganizador(null); // Reinicia el estado del organizador
      setId(''); // Reinicia el campo de ID
    } catch (error) {
      alert('Error al eliminar organizador: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Eliminar Organizador</h2>
              {/* Formulario para buscar el organizador por ID */}
              <form onSubmit={handleBuscar}>
                <div className="mb-3">
                  <input
                    type="number"
                    className="form-control"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    placeholder="Digite el ID del Organizador"
                    required
                  />
                </div>
                <div className="d-grid">
                  <button type="submit" className="btn btn-primary">Buscar Organizador</button>
                </div>
              </form>

              {/* Mostrar información del organizador si se encuentra */}
              {organizador && (
                <div className="mt-4">
                  <h5>Información del Organizador</h5>
                  <p><strong>Nombre:</strong> {organizador.nombre}</p>
                  <p><strong>Presupuesto:</strong> ${organizador.presupuesto}</p>
                  <p><strong>Fecha de Fundación:</strong> {new Date(organizador.fundacion).toLocaleDateString()}</p>
                  <p><strong>CEO:</strong> {organizador.ceo}</p>
                  <p><strong>ID Feria Gastronómica:</strong> {organizador.feriaGastroId}</p>
                  <div className="d-grid">
                    <button onClick={handleEliminar} className="btn btn-danger">
                      Eliminar Organizador
                    </button>
                  </div>
                </div>
              )}

              {/* Mensaje de éxito al eliminar */}
              {eliminado && (
                <div className="alert alert-success mt-3" role="alert">
                  Organizador eliminado correctamente.
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EliminarOrganizador;
