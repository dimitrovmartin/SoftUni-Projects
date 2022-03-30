import * as api from './api.js';


const endpoints = {
     search: (query) => `/data/albums?where=${query}`,
     albums: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
     create: '/data/albums',
     byId: '/data/albums/',
     deleteById: '/data/albums/',
     editById: '/data/albums/'
};

export async function search(search) {
    const query = encodeURIComponent(`name LIKE "${search}"`)
    return api.get(endpoints.search(query));
}

export async function getAll() {
    return api.get(endpoints.albums);
}

export async function create(data) {
    return api.post(endpoints.create, data);
}

export async function getById(id) {
    return api.get(endpoints.byId + id);
}

export async function deleteById(id){
    return api.del(endpoints.deleteById + id);
}

export async function update(id, data){
    return api.put(endpoints.editById + id, data);
}