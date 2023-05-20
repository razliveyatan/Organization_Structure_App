import type { IResponse } from "../types/interfaces/interfaces";

export const encodeData = (data: any) => {
    const params = [];
    for (let key in data) {
        if (data.hasOwnProperty(key)) {
            params.push(key + "=" + window.encodeURIComponent(data[key]));
        }
    }
    return params.join('&');
}

export const get = async (url: string, data: any = null) => {
    if (data) {
        const qs = encodeData(data);
        url += `?${qs}`;
    }

    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Accept', '*/*');
    headers.append('Accept-Encoding', 'gzip, deflate, br');
    headers.append('Accept-Language', 'en-GB,en-US;q=0.9,en;q=0.8');
    headers.append('Access-Control-Allow-Origin','localhost:3000')
    //headers.append('pragma', 'no-cache');
    //headers.append('cache-control', 'no-cache');

    const response = await fetch(url, {
        method: 'GET',
        headers,       
        credentials: 'same-origin',
    })
    return {
        data: await response.json(),
        statusCode: response.status,
    }
}

export const post = async (url: string, data: any = null): Promise<IResponse> => {
    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': 'localhost:3000'
        },
        credentials: 'same-origin',
        body: JSON.stringify(data)
    });

    return {
        data: await response.json(),
        statusCode: response.status,
    }
}

export const put = async (url: string, data: any = null): Promise<IResponse> => {
    const response = await fetch(url, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        credentials: 'same-origin',
        body: JSON.stringify(data),
    });

    return {
        data: await response.json(),
        statusCode: response.status,
    }
}

export const del = async (url: string, data: any = null): Promise<IResponse> => {
    const response = await fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        credentials: 'same-origin',
        body: JSON.stringify(data),
    });

    return {
        data: await response.json(),
        statusCode: response.status,
    }
}