import React, { useState } from 'react';
import { listarOrganizador, listarOrganizadorPorInicial } from '../../services/organizadorService';

const ListarOrganizadores = () => {
  const [organizadores, setOrganizadores] = useState([]);
  const [inicial, setInicial] = useState('');
  const [error, setError] = useState('');

  // Manejador para listar todos los organizadores
  const handleListar = async () => {
    try {
      const resultado = await listarOrganizador();
      setOrganizadores(resultado);
      setError(''); // Reinicia el estado de error
    } catch (error) {
      setError('Error al listar organizadores: ' + error.message);
    }
  };

  // Manejador para filtrar organizadores por inicial
  const handleFiltrar = async (e) => {
    e.preventDefault();
    try {
      const resultado = await listarOrganizadorPorInicial(inicial);
      setOrganizadores(resultado);
      setError(''); // Reinicia el estado de error
    } catch (error) {
      setError('Error al filtrar organizadores: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-8">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Listar Organizadores</h2>

              {/* Botón para listar todos los organizadores */}
              <div className="d-grid mb-3">
                <button onClick={handleListar} className="btn btn-primary">
                  Listar Todos los Organizadores
                </button>
              </div>

              {/* Sección para filtrar por inicial */}
              <form onSubmit={handleFiltrar} className="mb-4">
                <div className="input-group">
                  <input
                    type="text"
                    className="form-control"
                    value={inicial}
                    onChange={(e) => setInicial(e.target.value)}
                    placeholder="Inicial del nombre"
                    required
                  />
                  <button type="submit" className="btn btn-secondary">
                    Filtrar
                  </button>
                </div>
              </form>

              {/* Mensaje de error si ocurre algún problema */}
              {error && (
                <div className="alert alert-danger" role="alert">
                  {error}
                </div>
              )}

              {/* Tabla para mostrar los organizadores */}
              {organizadores.length > 0 && (
                <table className="table table-striped mt-4">
                  <thead>
                    <tr>
                      <th>ID</th>
                      <th>Nombre</th>
                      <th>Presupuesto</th>
                      <th>Fecha de Fundación</th>
                      <th>CEO</th>
                      <th>ID Feria Gastronómica</th>
                    </tr>
                  </thead>
                  <tbody>
                    {organizadores.map((organizador) => (
                      <tr key={organizador.id}>
                        <td>{organizador.id}</td>
                        <td>{organizador.nombre}</td>
                        <td>${organizador.presupuesto}</td>
                        <td>{new Date(organizador.fundacion).toLocaleDateString()}</td>
                        <td>{organizador.ceo}</td>
                        <td>{organizador.feriaGastroId}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ListarOrganizadores;
