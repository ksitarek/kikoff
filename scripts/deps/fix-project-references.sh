#!/usr/bin/env bash

function fix_slnx_references() {
  local slnx_file="${REPO_ROOT}/${NEW_NAME}.slnx"

  if [[ ! -f "${slnx_file}" ]]; then
    echo "  Warning: ${NEW_NAME}.slnx not found, skipping slnx reference fix." >&2
    return
  fi

  echo "Fixing project references in .slnx file..."
  sed -i '' "s/${OLD_NAME}/${NEW_NAME}/g" "${slnx_file}"
  echo "  Updated references in ${NEW_NAME}.slnx"
}

function fix_csproj_references() {
  echo "Fixing project references in .csproj files..."

  local csproj_files
  csproj_files="$(find "${REPO_ROOT}/src" -name "*.csproj" -type f | sort)"

  local csproj
  while IFS= read -r csproj; do
    [[ -z "${csproj}" ]] && continue
    if grep -q "${OLD_NAME}" "${csproj}" 2>/dev/null; then
      sed -i '' "s/${OLD_NAME}/${NEW_NAME}/g" "${csproj}"
      local rel_path="${csproj#"${REPO_ROOT}"/}"
      echo "  Updated references in ${rel_path}"
    fi
  done <<< "${csproj_files}"
}
