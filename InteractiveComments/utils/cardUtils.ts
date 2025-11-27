import { API_URL, type Comment } from './apiCall'

export const formatDate = (comment: Comment) => {
  if (!comment.createdAt) return 'today'
  const now = new Date()
  const created = new Date(comment.createdAt)
  const diffMs = now.getTime() - created.getTime()
  const diffDays = Math.floor(diffMs / (1000 * 60 * 60 * 24))

  if (diffDays < 1) return 'today'
  if (diffDays < 7) return `${diffDays} day${diffDays > 1 ? 's' : ''} ago`
  if (diffDays < 30)
    return `${Math.floor(diffDays / 7)} week${Math.floor(diffDays / 7) > 1 ? 's' : ''} ago`
  return `${Math.floor(diffDays / 30)} month${Math.floor(diffDays / 30) > 1 ? 's' : ''} ago`
}

export const getAvatarUrl = (comment: Comment) => {
  const assets = comment.user?.assets
  let path = assets?.find((a) => a.path.includes('webp'))?.path
  if (!path) path = assets?.[0]?.path
  return API_URL + path?.substring(1)
}
