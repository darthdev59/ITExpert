import { useEffect, useState } from 'react';
import { IValuesResponse } from '../Abstractions/IValuesResponse';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { Box } from '@mui/material';

function DataGridComponent() {
    const [valuesData, setValues] = useState<IValuesResponse>();

    useEffect(() => {
        const GetData = async () => {
            const response = await fetch("https://localhost:7091/values", {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "*/*"
                }
            });
            const json: IValuesResponse | undefined = await response.json();
            if (response.ok) setValues(json);
        }
        GetData();
    });

    const columns: GridColDef[] = [
        {
            field: 'row',
            headerName: 'Row',
            type: 'number',
            width: 100,
            headerClassName: 'super-app-theme--header'
        },
        {
            field: 'code',
            headerName: 'Code',
            type: 'number',
            width: 120,
            headerClassName: 'super-app-theme--header'
        },
        {
            field: 'value',
            headerName: 'Value',
            type: 'string',
            width: 200,
            headerClassName: 'super-app-theme--header'
        },
    ]

    return (
        <Box
            sx={{
                height: 300,
                width: '100%',
                '& .super-app-theme--header': {
                    color: 'black'
                },
                '& .MuiTablePagination-toolbar': {
                    color: 'white'
                },
                '& .MuiTablePagination-selectIcon': {
                    color: 'white'
                },
                '& .MuiIconButton-root': {
                    color: 'white'
                }
            }}>
        <div style={{ height: 400, width: '100%' }}>
                <DataGrid
                    rows={valuesData ? valuesData.data : []}
                    columns={columns}
                    initialState={{
                        pagination: {
                            paginationModel: { page: 0, pageSize: 5 },
                        },

                    }}
                    pageSizeOptions={[5, 10, 15]}
                    checkboxSelection={false}
                    getRowId={(row) => row.row}
                    sx={{
                        color: 'white'
                    }}
            />
            </div>
        </Box>
    );
}

export default DataGridComponent;