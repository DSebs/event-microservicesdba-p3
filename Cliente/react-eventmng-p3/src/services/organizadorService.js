import axios from 'axios';

const API_URL = 'http://localhost:8090/organizador';

export const agregarOrganizador = async (organizador) => {
  const response = await axios.post(`${API_URL}/crear`, organizador);
  return response.data;
};

export const buscarOrganizadorPorId = async (id) => {
  const response = await axios.get(`${API_URL}/buscar/${id}`);
  return response.data;
};

export const buscarOrganizadorPorNombre = async (nombre) => {
  const response = await axios.get(`${API_URL}/buscar/nombre/${nombre}`);
  return response.data;
};

export const actualizarOrganizador = async (id, organizador) => {
  const response = await axios.put(`${API_URL}/${id}`, organizador);
  return response.data;
};

export const eliminarOrganizador = async (id) => {
    await axios.delete(`${API_URL}/eliminar/${id}`);
  };  

export const listarOrganizador = async () => {
  const response = await axios.get(`${API_URL}/listar`);
  return response.data;
};

export const listarOrganizadorPorInicial = async (inicial) => {
  const response = await axios.get(`${API_URL}/listar/inicial/${inicial}`);
  return response.data;
};