import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getProduct, updateProduct } from '../services/api';

const Edit = () => {
  const [product, setProduct] = useState('');
  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    fetchItem();
  }, []);

  const fetchItem = async () => {
    const response = await getProduct(id);
    setProduct(response.data);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await updateItem(id, { name });
    navigate('/');
  };

  return (
    <div className="container mt-4">
      <h2>Edit Item</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="name">Name</label>
          <input
            type="text"
            className="form-control"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary">Update</button>
      </form>
    </div>
  );
};

export default Edit;
