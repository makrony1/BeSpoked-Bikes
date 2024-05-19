import React, { useState } from 'react';

const SearchableDropdown = ({ options, onSelect }) => {
  const [search, setSearch] = useState('');
  const [filteredOptions, setFilteredOptions] = useState(options);
  const [dropdownVisible, setDropdownVisible] = useState(false);

  const handleSearchChange = (e) => {
    const value = e.target.value;
    setSearch(value);
    const filtered = options.filter(option =>
      option.Text.toLowerCase().includes(value.toLowerCase())
    );
    setFilteredOptions(filtered);
  };

  const handleOptionClick = (option) => {
    setSearch(option.Text);
    setDropdownVisible(false);
    onSelect(option);
  };

  const handleInputClick = () => {
    setDropdownVisible(!dropdownVisible);
  };

  return (
    <div className="dropdown">
      <input
        type="text"
        className="form-control"
        value={search}
        onChange={handleSearchChange}
        onClick={handleInputClick}
        placeholder="Search..."
      />
      {dropdownVisible && (
        <div className="dropdown-menu show" style={{ width: '100%' }}>
          {filteredOptions.length > 0 ? (
            filteredOptions.map((option, index) => (
              <button
                key={option.Id}
                className="dropdown-item"
                onClick={() => handleOptionClick(option)}
              >
                {option.Text}
              </button>
            ))
          ) : (
            <div className="dropdown-item">No results found</div>
          )}
        </div>
      )}
    </div>
  );
};

export default SearchableDropdown;
