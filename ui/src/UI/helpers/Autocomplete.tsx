import React, { useState } from 'react';

type AutocompleteProps = {
    dataSource: any[],
    renderItem: (item: any) => React.ReactNode,
    onSelect: (item: any) => void,
    placeholder?: string
}
const Autocomplete = (props: AutocompleteProps) => {
    const [inputValue, setInputValue] = useState('');
    const [filteredData, setFilteredData] = useState(props.dataSource);

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
        const filtered = props.dataSource.filter((item) => {
            return item.firstName.toLowerCase().includes(event.target.value.toLowerCase());
        });
        setFilteredData(filtered);
    };    

    const handleSelect = (item: any) => {
        setInputValue('');
        setFilteredData(props.dataSource);
        props.onSelect(item);
    };

    return (
        <div className='search-container'>
            <input type="text" value={inputValue} onChange={handleInputChange} placeholder={props.placeholder} />
            <div className='search-results'>
                {filteredData.map((item, index) => (
                    <div className='employee-item' key={item.employeeId
                    } onClick={() => handleSelect(item)}>
                        {props.renderItem(item)}
                    </div>
                ))}
                {
                    filteredData.length === 0 && <div className="item error">
                        <p>No results found!</p>
                    </div>
                }                
            </div>
        </div>
    );
}

export default Autocomplete;