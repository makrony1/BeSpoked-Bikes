import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:44357/api', // Replace with your API base URL
});

export const getProducts = () => api.get('/products');
export const getProduct = (id) => api.get(`/products/${id}`);
export const createProduct = (item) => api.post('/products', item);
export const updateProduct = (id, item) => api.put(`/products/${id}`, item);
export const getCustomers = () => api.get('/customer');
export const getSales = () => api.get('/sales');
export const createSales = (item) => api.post('/sales', item);
export const getSalespeople = () => api.get('/salesperson');
export const getSalesperson = (id) => api.get(`/salesperson/${id}`);
export const updateSalesperson = (id, item) => api.put(`/salesperson/${id}`, item);

export default api;
