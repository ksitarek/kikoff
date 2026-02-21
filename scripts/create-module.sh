#!/usr/bin/env bash
set -euo pipefail

# ── Module name prompt ────────────────────────────────────────────────────────

MODULE_NAME="${1:-}"
if [[ -z "${MODULE_NAME}" ]]; then
  read -r -p "Enter module name: " MODULE_NAME
  MODULE_NAME="$(echo "${MODULE_NAME}" | xargs)"
fi

if [[ -z "${MODULE_NAME}" ]]; then
  echo "Error: Module name cannot be empty." >&2
  exit 1
fi

if [[ ! "${MODULE_NAME}" =~ ^[A-Za-z][A-Za-z0-9_]*$ ]]; then
  echo "Error: Invalid module name '${MODULE_NAME}'. Use letters, digits, and underscore; must start with a letter." >&2
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
SOLUTION_NAME="$(basename "${SOLUTION_FILE}" .slnx)"

MODULES_FILE="${REPO_ROOT}/modules.json"

MODULE_ROOT="${REPO_ROOT}/src/Modules/${MODULE_NAME}"
TESTS_ROOT="${MODULE_ROOT}/Tests"

PROJECT_APPLICATION="${SOLUTION_NAME}.Modules.${MODULE_NAME}.Application"
PROJECT_INFRASTRUCTURE="${SOLUTION_NAME}.Modules.${MODULE_NAME}.Infrastructure"
PROJECT_DOMAIN="${SOLUTION_NAME}.Modules.${MODULE_NAME}.Domain"
PROJECT_PUBLISHED_LANGUAGE="${SOLUTION_NAME}.Modules.${MODULE_NAME}.PublishedLanguage"

CLASSLIB_PROJECTS=(
  "${PROJECT_APPLICATION}"
  "${PROJECT_INFRASTRUCTURE}"
  "${PROJECT_DOMAIN}"
  "${PROJECT_PUBLISHED_LANGUAGE}"
)

TEST_APPLICATION="${SOLUTION_NAME}.Modules.${MODULE_NAME}.Tests.Application"
TEST_INFRASTRUCTURE="${SOLUTION_NAME}.Modules.${MODULE_NAME}.Tests.Infrastructure"
TEST_DOMAIN="${SOLUTION_NAME}.Modules.${MODULE_NAME}.Tests.Domain"

TEST_PROJECTS=(
  "${TEST_DOMAIN}"
  "${TEST_INFRASTRUCTURE}"
  "${TEST_APPLICATION}"
)

# ── Source function definitions ───────────────────────────────────────────────

DEPS_DIR="${SCRIPT_DIR}/deps"
source "${DEPS_DIR}/assert-clean-worktree.sh"
source "${DEPS_DIR}/create-directories.sh"
source "${DEPS_DIR}/create-classlib-projects.sh"
source "${DEPS_DIR}/create-test-projects.sh"
source "${DEPS_DIR}/update-modules-json.sh"
source "${DEPS_DIR}/add-projects-to-solution.sh"
source "${DEPS_DIR}/verify-build.sh"

# ── Execute ───────────────────────────────────────────────────────────────────

assert_clean_worktree

echo "Scaffolding module '${MODULE_NAME}'..."

create_directories
create_classlib_projects
create_test_projects
update_modules_json
add_projects_to_solution
verify_build

echo "Module '${MODULE_NAME}' scaffolding complete."
