import React, { useState } from 'react';
import { listarFeriaGastro, listarFeriaGastroPorPrecio } from '../../services/feriaGastroService';

  const ListarFeria = () => {
  const [ferias, setFerias] = useState([]);
  const [precioMax, setPrecioMax] = useState('');
  const [error, setError] = useState('');

  const handleListar = async () => {
    try {
      const resultado = await listarFeriaGastro();
      setFerias(resultado);
      setError('');
    } catch (error) {
      setError('Error al listar ferias: ' + error.message);
    }
  };

  const handleFiltrar = async (e) => {
    e.preventDefault();
    try {
      const resultado = await listarFeriaGastroPorPrecio(precioMax);
      setFerias(resultado);
      setError('');
    } catch (error) {
      setError('Error al filtrar ferias: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-8">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Listar Ferias</h2>

              <div className="d-grid mb-3">
                <button onClick={handleListar} className="btn btn-primary">
                  Listar Todas las Ferias
                </button>
              </div>

              <form onSubmit={handleFiltrar} className="mb-4">
                <div className="input-group">
                  <input
                    type="number"
                    className="form-control"
                    value={precioMax}
                    onChange={(e) => setPrecioMax(e.target.value)}
                    placeholder="Precio máximo"
                    required
                  />
                  <button type="submit" className="btn btn-secondary">
                    Filtrar
                  </button>
                </div>
              </form>

              {error && (
                <div className="alert alert-danger" role="alert">
                  {error}
                </div>
              )}

              {ferias.length > 0 && (
                <table className="table table-striped mt-4">
                  <thead>
                    <tr>
                      <th>ID</th>
                      <th>Nombre</th>
                      <th>Precio</th>
                      <th>Fecha de Realización</th>
                      <th>Tipo</th>
                      <th>Organizadores</th>
                    </tr>
                  </thead>
                  <tbody>
                    {ferias.map((feria) => (
                      <tr key={feria.id}>
                        <td>{feria.id}</td>
                        <td>{feria.nombre}</td>
                        <td>{feria.precio}</td>
                        <td>{new Date(feria.fechaRealizacion).toLocaleDateString()}</td>
                        <td>{feria.tipo}</td>
                        <td>{feria.organizadorIds.join(', ')}</td>
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

export default ListarFeria;
