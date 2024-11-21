import React, { useState } from 'react';
import { buscarOrganizadorPorNombre } from '../../services/organizadorService';

const BuscarOrganizadorNombre = () => {
  const [nombre, setNombre] = useState('');
  const [organizador, setOrganizador] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const resultado = await buscarOrganizadorPorNombre(nombre);
      setOrganizador(resultado);
    } catch (error) {
      alert('Error al buscar organizador: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Buscar Organizador por Nombre</h2>
              <form onSubmit={handleSubmit}>
                <div className="mb-3">
                  <input
                    type="text"
                    className="form-control"
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                    placeholder="Digite el Nombre"
                    required
                  />
                </div>
                <div className="d-grid">
                  <button type="submit" className="btn btn-primary">Buscar</button>
                </div>
              </form>
              {organizador && (
                <div className="mt-4">
                  <h3>Resultado:</h3>
                  <p>ID: {organizador.id}</p>
                  <p>Nombre: {organizador.nombre}</p>
                  <p>Presupuesto: ${organizador.presupuesto}</p>
                  <p>Fecha de Fundación: {new Date(organizador.fundacion).toLocaleDateString()}</p>
                  <p>CEO: {organizador.ceo}</p>
                  <p>ID Feria Gastronómica: {organizador.feriaGastroId}</p>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default BuscarOrganizadorNombre;
