import * as api from './api.js';


const endpoints = {
     recent: '/data/books?sortBy=_createdOn%20desc',
     books: (id) => `/data/books?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`,
     create: '/data/books',
     byId: '/data/books/',
     deleteById: '/data/books/',
     editById: '/data/books/'
};

export async function getRecent () {
    return api.get(endpoints.recent);
}

export async function getAll(id) {
    return api.get(endpoints.books(id));
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