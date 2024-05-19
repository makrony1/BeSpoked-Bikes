import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getProduct, updateProduct } from '../../services/api';

const EditProduct = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [product, setProduct] = useState({
    id: '',
    name: '',
    manufacturer: '',
    style: '',
    salePrice: 0,
    purchasePrice: 0,
    qtyOnHand: 0,
    commissionPercentage: 0
  });
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchProduct = async () => {
      try {
        const response = await getProduct(id);
        setProduct(response.data);
        setLoading(false);
      } catch (err) {
        setError(JSON.stringify(err.response.data.errors));
        setLoading(false);
      }
    };

    fetchProduct();
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProduct({ ...product, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
        await updateProduct(id, product);
      //await axios.put(`/api/products/${id}`, product);
      navigate('/product');
    } catch (err) {
        setError(JSON.stringify(err.response.data.errors));
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }


  return (
    <div className="container mt-4">
        <div className='text-danger'>{error}</div>
      <h2>Edit Product</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="name">Name</label>
          <input
            type="text"
            className="form-control"
            id="name"
            name="name"
            value={product.name}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="manufacturer">Manufacturer</label>
          <input
            type="text"
            className="form-control"
            id="manufacturer"
            name="manufacturer"
            value={product.manufacturer}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="style">Style</label>
          <input
            type="text"
            className="form-control"
            id="style"
            name="style"
            value={product.style}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="salePrice">Sale Price</label>
          <input
            type="number"
            className="form-control"
            id="salePrice"
            name="salePrice"
            value={product.salePrice}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="purchasePrice">Purchase Price</label>
          <input
            type="number"
            className="form-control"
            id="purchasePrice"
            name="purchasePrice"
            value={product.purchasePrice}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="qtyOnHand">Quantity On Hand</label>
          <input
            type="number"
            className="form-control"
            id="qtyOnHand"
            name="qtyOnHand"
            value={product.qtyOnHand}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="commissionPercentage">Commission Percentage</label>
          <input
            type="number"
            className="form-control"
            id="commissionPercentage"
            name="commissionPercentage"
            value={product.commissionPercentage}
            onChange={handleChange}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary">Update Product</button>
      </form>
    </div>
  );
};

export default EditProduct;
