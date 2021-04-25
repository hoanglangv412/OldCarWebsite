export const Domain = "https://localhost:44343/api/";
var session = null;

export function setSession(value){
    session = value;
}
export function getSession(){
    return session;
}
  