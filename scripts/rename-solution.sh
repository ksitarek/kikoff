#!/usr/bin/env bash
set -euo pipefail

# ── New name prompt ───────────────────────────────────────────────────────────

NEW_NAME="${1:-}"
if [[ -z "${NEW_NAME}" ]]; then
  read -r -p "Enter new solution name: " NEW_NAME
  NEW_NAME="$(echo "${NEW_NAME}" | xargs)"
fi

if [[ -z "${NEW_NAME}" ]]; then
  echo "Error: Solution name cannot be empty." >&2
  exit 1
fi

if [[ ! "${NEW_NAME}" =~ ^[A-Za-z][A-Za-z0-9_]*$ ]]; then
  echo "Error: Invalid solution name '${NEW_NAME}'. Use letters, digits, and underscore; must start with a letter." >&2
  exit 1
fi

# ── Variables ─────────────────────────────────────────────────────────────────

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
REPO_ROOT="$(cd "${SCRIPT_DIR}/.." && pwd)"

SOLUTION_FILE="$(find "${REPO_ROOT}" -maxdepth 1 -name '*.slnx' -type f | head -n 1)"
if [[ -z "${SOLUTION_FILE}" ]]; then
  echo "Error: No .slnx file found in ${REPO_ROOT}" >&2
  exit 1
fi

OLD_NAME="$(basename "${SOLUTION_FILE}" .slnx)"

if [[ "${OLD_NAME}" == "${NEW_NAME}" ]]; then
  echo "Solution is already named '${NEW_NAME}'. Nothing to do."
  exit 0
fi

# ── Source function definitions ───────────────────────────────────────────────

DEPS_DIR="${SCRIPT_DIR}/deps"
source "${DEPS_DIR}/rename-directories.sh"
source "${DEPS_DIR}/rename-csproj-files.sh"
source "${DEPS_DIR}/rename-slnx-file.sh"
source "${DEPS_DIR}/fix-project-references.sh"
source "${DEPS_DIR}/fix-cs-namespaces.sh"

# ── Execute ───────────────────────────────────────────────────────────────────

echo "Renaming solution '${OLD_NAME}' -> '${NEW_NAME}'..."

rename_directories
rename_csproj_files
rename_slnx_file
fix_csproj_references
fix_slnx_references
fix_cs_namespaces

echo "Solution renamed to '${NEW_NAME}' successfully."
