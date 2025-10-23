import type { components } from '../types'
const API_URL = 'http://localhost:5048/'

export const imageUrl: (path: string) => string = (path) => API_URL + 'images/' + path

export const apiUrl: (path: string) => string = (path) => API_URL + path

type ApiResponse<T> = { data?: T; error?: { status: number; message?: string } }

export type Comment = components['schemas']['Comment']
export type User = components['schemas']['User']
export type Asset = components['schemas']['Asset']

export const fetchApi = async <T>(path: string, options?: RequestInit): Promise<ApiResponse<T>> => {
  try {
    const response = await fetch(apiUrl(path), options)

    if (!response.ok) {
      let message = `HTTP error! status: ${response.status}`
      try {
        const errorData = await response.clone().json()
        if (errorData && typeof errorData === 'object' && 'message' in errorData) {
          message = errorData.message as string
        }
      } catch {
        // No JSON body
      }
      return { error: { status: response.status, message } }
    }

    const contentLength = response.headers.get('content-length')
    if (response.status === 204 || contentLength === '0' || contentLength === null) {
      return { data: undefined as T }
    }

    const data = await response.json()
    return { data: data as T }
  } catch (error) {
    return { error: { status: 0, message: error instanceof Error ? error.message : 'Unknown error' } }
  }
}

// Typed API functions
export const getComments = (): Promise<ApiResponse<Comment[]>> => fetchApi<Comment[]>('/comments')
export const getUsers = (): Promise<ApiResponse<User[]>> => fetchApi<User[]>('/users')
export const createComment = (comment: Comment): Promise<ApiResponse<Comment>> => 
  fetchApi<Comment>('/comment', { 
    method: 'POST', 
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(comment) 
  })
export const deleteComment = (id: number): Promise<ApiResponse<undefined>> => 
  fetchApi<undefined>('/comment/' + id, { method: 'DELETE' })
