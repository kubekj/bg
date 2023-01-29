export const Url = "http://localhost:5099/api";

export default async function fetcher(endpoint, options = {}) {
  let response;
  const url = `${Url}/${endpoint}`;
  if (!options) {
    response = await fetch(url);
  } else {
    response = await fetch(url, options);
  }
  const data = await response.json();
  return data;
}

export async function poster(endpoint, data) {
  const url = `${Url}/${endpoint}`;

  const response = await fetch(url, {
    method: "POST",
    body: JSON.stringify(data),
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${jwt}`,
    },
  });
  const resp = await response.json();
  return resp;
}

export async function signin(data) {
  const url = `${Url}/users/signin`;
  const response = await fetch(url, {
    method: "POST",
    body: JSON.stringify(data),
    headers: {
      "Content-Type": "application/json",
    },
  });
  const resp = await response.json();
  return resp;
}

export async function putter(endpoint, data, jwt) {
  const url = `${Url}/${endpoint}`;
  console.log(jwt);
  await fetch(url, {
    method: "PUT",
    body: JSON.stringify(data),
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${jwt}`,
    },
  });
}

export async function deleter(endpoint, jwt) {
  const url = `${Url}/${endpoint}`;
  await fetch(url, {
    method: "DELETE",
    headers: {
      Authorization: `Bearer ${jwt}`,
    },
  });
}
