import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createProduct } from '../services/api';

const Create = () => {
  const [name, setName] = useState('');
  const history = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    await createProduct({ name });
    history.push('/');
  };

  return (
    <div className="container mt-4">
      <h2>Create Item</h2>
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
        <button type="submit" className="btn btn-primary">Create</button>
      </form>
    </div>
  );
};

export default Create;
