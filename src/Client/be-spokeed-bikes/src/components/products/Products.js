import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getProducts } from '../../services/api';

const Products = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        fetchItems();
    }, []);

    const fetchItems = async () => {
        const response = await getProducts();
        setProducts(response.data);
    };

    const handleDelete = async (id) => {
        //await deleteItem(id);
        fetchItems();
    };

    return (
        <div className="container mt-4">
            <h2>Products</h2>
            <div className='text-right'>
                <Link className="btn btn-primary float-end" to={`/product/create`}>Create</Link>
            </div>
            <div>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Name</th>
                            <th scope="col">Manufacturer</th>
                            <th scope="col">Style</th>
                            <th scope="col">Purchase Price</th>
                            <th scope="col">Sale Price</th>
                            <th scope="col">Qty On Hand</th>
                            <th scope="col">Commission Percentage</th>
                        </tr>
                    </thead>
                    <tbody>
                        {products.map(item =>
                        (<tr>
                            <td>{item.name}</td>
                            <td>{item.manufacturer}</td>
                            <td>{item.style}</td>
                            <td>{item.purchasePrice}</td>
                            <td>{item.salePrice}</td>
                            <td>{item.qtyOnHand}</td>
                            <td>{item.commissionPercentage} %</td>
                            <td>
                                <div>
                                    <Link className="btn btn-link btn-sm mr-2" to={`/product/edit/${item.id}`}>Edit</Link>
                                </div>
                            </td>
                        </tr>)
                        )}

                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default Products;
