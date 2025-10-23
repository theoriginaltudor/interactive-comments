const API_URL = 'http://localhost:5048/'

export const imageUrl: (path: string) => string = (path) => API_URL + 'images/' + path

export const apiUrl: (path: string) => string = (path) => API_URL + path

export const fetchApi: (path: string, options?: RequestInit) => Promise = async (path, options) => {
  const response = await fetch(apiUrl(path), options)

  if (!response.ok)
    return {
      status: response.status,
    }

  const data = await response.json()

  return data
}
