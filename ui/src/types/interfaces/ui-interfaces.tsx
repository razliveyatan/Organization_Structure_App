export interface AutocompleteProps {
    dataSource: any[],
    renderItem: (item: any) => React.ReactNode,
    onSelect: (item: any) => void,
    placeholder?: string
}