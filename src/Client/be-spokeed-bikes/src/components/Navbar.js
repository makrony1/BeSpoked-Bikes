import React from 'react';
import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container-fluid">
                <Link className="navbar-brand" to="/">BeSpoked Bikes</Link>
                <div className="collapse navbar-collapse">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item">
                            <Link className="nav-link" to="/">Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/product">Products</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/customer">Customer</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/salesperson">Salesperson</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/sales">Sales</Link>
                        </li>
                    </ul>
                </div>

            </div>

        </nav>
    );
};

export default Navbar;
