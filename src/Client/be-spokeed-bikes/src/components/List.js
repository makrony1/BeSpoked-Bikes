import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getProduct } from '../services/api';

const MyList = () => {
  const [items, setItems] = useState([]);

  useEffect(() => {
    console.log("Im here");

    fetchItems();
  }, []);

  const fetchItems = async () => {
    const response = await getItems();
    setItems(response);
  };

  const handleDelete = async (id) => {
    //await deleteItem(id);
    fetchItems();
  };

  return (
    <div className="container mt-4">
      <h2>List of Items</h2>
      <ul className="list-group">
        {items.map(item => (
          <li key={item.id} className="list-group-item d-flex justify-content-between align-items-center">
            {item.name}
            <div>
              <Link className="btn btn-primary btn-sm mr-2" to={`/edit/${item.id}`}>Edit</Link>
              <button className="btn btn-danger btn-sm" onClick={() => handleDelete(item.id)}>Delete</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default MyList;
