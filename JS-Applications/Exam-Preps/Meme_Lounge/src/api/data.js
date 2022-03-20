import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllMemes(){
    return api.get('/data/memes?sortBy=_createdOn%20desc');
}

export async function createMeme(meme){
    return api.post('/data/memes', meme);
}

export async function getMemeById(id){
    return api.get('/data/memes/' + id);
}

export async function deleteById(id){
    return api.del('/data/memes/' + id);
}

export async function editById(id, data){
    return api.put('/data/memes/' + id, data);
}

export async function getMyMemes(id){
    return api.get(`/data/memes?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`);
}