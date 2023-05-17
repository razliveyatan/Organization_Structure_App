import React, { useState} from 'react';
type AutocompleteProps = {
    dataSource: any[],
    renderItem: (item: any) => React.ReactNode,
    onSelect: (item: any) => void,
    placeholder?: string
}
const Autocomplete = (props: AutocompleteProps) => {
    const [inputValue, setInputValue] = useState('');

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
    };

    const handleSelect = (item: any) => {
        setInputValue('');
        props.onSelect(item);
    };

    return (
        <div>
            <input type="text" value={inputValue} onChange={handleInputChange} placeholder={props.placeholder} />
            <ul>
                {props.dataSource.map((item, index) => (
                    <li key={index} onClick={() => handleSelect(item)}>
                        {props.renderItem(item)}
                    </li>
                ))}
            </ul>
        </div>
    );
}
}

export default Autocomplete;