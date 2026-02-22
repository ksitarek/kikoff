#!/usr/bin/env bash

function add_projects_to_solution() {
  if [[ ! -f "${SOLUTION_FILE}" ]]; then
    echo "Error: Solution file not found: ${SOLUTION_FILE}" >&2
    exit 1
  fi

  echo "Adding projects to solution..."
  local csproj_files
  csproj_files="$(find "${MODULE_ROOT}" -name "*.csproj"  -type f | sort)"

  local csproj
  while IFS= read -r csproj; do
    [[ -z "${csproj}" ]] && continue
    local rel_path="${csproj#"${REPO_ROOT}"/}"
    if dotnet sln "${SOLUTION_FILE}" add "${csproj}" -s "Modules/${MODULE_NAME}" >/dev/null 2>&1; then
      echo "  Added: ${rel_path}"
    else
      echo "  Warning: Failed to add ${rel_path}" >&2
    fi
  done <<< "${csproj_files}"
}
