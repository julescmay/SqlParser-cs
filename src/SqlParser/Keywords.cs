﻿// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System.Reflection;

namespace SqlParser;

internal static class Keywords
{
    /// <summary>
    /// Builds a list of SQL keywords from the enumeration
    /// </summary>
    static Keywords()
    {
        var renamedKeywords = new Dictionary<string, string>
        {
            {"END_EXEC", "END-EXEC"}
        };
        var keywords = Enum.GetNames(typeof(Keyword))
                .Where(n => n != nameof(Keyword.undefined))
                .ToArray();

        foreach (var renamed in renamedKeywords)
        {
            var index = Array.FindIndex(keywords, k => k == renamed.Key);
            if (index > -1)
            {
                keywords[index] = renamed.Value;
            }
        }

        All = keywords.ToArray();
    }

    internal static readonly string[] All;

    /// These keywords can't be used as a table alias, so that `FROM table_name alias`
    /// can be parsed unambiguously without looking ahead.
    internal static readonly Keyword[] ReservedForColumnAlias = {
        // Reserved as both a table and a column alias:
        Keyword.WITH,
        Keyword.EXPLAIN,
        Keyword.ANALYZE,
        Keyword.SELECT,
        Keyword.WHERE,
        Keyword.GROUP,
        Keyword.SORT,
        Keyword.HAVING,
        Keyword.ORDER,
        Keyword.TOP,
        Keyword.LATERAL,
        Keyword.VIEW,
        Keyword.LIMIT,
        Keyword.OFFSET,
        Keyword.FETCH,
        Keyword.UNION,
        Keyword.EXCEPT,
        Keyword.INTERSECT,
        Keyword.CLUSTER,
        Keyword.DISTRIBUTE,
        // Reserved only as a column alias in the `SELECT` clause
        Keyword.FROM,
        Keyword.INTO,
        Keyword.END,
    };

    /// Can't be used as a column alias, so that `SELECT Expression alias`
    /// can be parsed unambiguously without looking ahead.
    internal static readonly Keyword[] ReservedForTableAlias =
    {
        // Reserved as both a table and a column alias:
        Keyword.WITH,
        Keyword.EXPLAIN,
        Keyword.ANALYZE,
        Keyword.SELECT,
        Keyword.WHERE,
        Keyword.GROUP,
        Keyword.SORT,
        Keyword.HAVING,
        Keyword.ORDER,
        Keyword.PIVOT,
        Keyword.TOP,
        Keyword.LATERAL,
        Keyword.VIEW,
        Keyword.LIMIT,
        Keyword.OFFSET,
        Keyword.FETCH,
        Keyword.UNION,
        Keyword.EXCEPT,
        Keyword.INTERSECT,
        // Reserved only as a table alias in the `FROM`/`JOIN` clauses:
        Keyword.ON,
        Keyword.JOIN,
        Keyword.INNER,
        Keyword.CROSS,
        Keyword.FULL,
        Keyword.LEFT,
        Keyword.RIGHT,
        Keyword.NATURAL,
        Keyword.USING,
        Keyword.CLUSTER,
        Keyword.DISTRIBUTE,
        // for MSSQL-specific OUTER APPLY (seems reserved in most dialects)
        Keyword.OUTER,
        Keyword.SET,
        Keyword.QUALIFY,
        Keyword.WINDOW,
        Keyword.END,
        Keyword.AS // TODO remove?
    };
}

// ReSharper disable InconsistentNaming
public enum Keyword
{
    ABORT,
    ABS,
    ABSOLUTE,
    ACTION,
    ADD,
    ADMIN,
    AGAINST,
    ALL,
    ALLOCATE,
    ALTER,
    ALWAYS,
    ANALYZE,
    AND,
    ANTI,
    ANY,
    APPLY,
    ARCHIVE,
    ARE,
    ARRAY,
    ARRAY_AGG,
    ARRAY_MAX_CARDINALITY,
    AS,
    ASC,
    ASENSITIVE,
    ASSERT,
    ASYMMETRIC,
    AT,
    ATOMIC,
    AUTHORIZATION,
    AUTO_INCREMENT,
    AUTOINCREMENT,
    AVG,
    AVRO,
    BACKWARD,
    BEGIN,
    BEGIN_FRAME,
    BEGIN_PARTITION,
    BETWEEN,
    BIGINT,
    BIGNUMERIC,
    BINARY,
    BLOB,
    BOOLEAN,
    BOTH,
    BTREE,
    BY,
    BYPASSRLS,
    BYTEA,
    CACHE,
    CALL,
    CALLED,
    CARDINALITY,
    CASCADE,
    CASCADED,
    CASE,
    CAST,
    CEIL,
    CEILING,
    CENTURY,
    CHAIN,
    CHANGE,
    CHAR,
    CHAR_LENGTH,
    CHARACTER,
    CHARACTER_LENGTH,
    CHARACTERS,
    CHARSET,
    CHECK,
    CLOB,
    CLONE,
    CLOSE,
    CLUSTER,
    COALESCE,
    COLLATE,
    COLLATION,
    COLLECT,
    COLUMN,
    COLUMNS,
    COMMENT,
    COMMIT,
    COMMITTED,
    COMPRESSION,
    COMPUTE,
    CONDITION,
    CONFLICT,
    CONNECT,
    CONNECTION,
    CONSTRAINT,
    CONTAINS,
    CONVERT,
    COPY,
    COPY_OPTIONS,
    CORR,
    CORRESPONDING,
    COUNT,
    COVAR_POP,
    COVAR_SAMP,
    CREATE,
    CREATEDB,
    CREATEROLE,
    CREDENTIALS,
    CROSS,
    CSV,
    CUBE,
    CUME_DIST,
    CURRENT,
    CURRENT_CATALOG,
    CURRENT_DATE,
    CURRENT_DEFAULT_TRANSFORM_GROUP,
    CURRENT_PATH,
    CURRENT_ROLE,
    CURRENT_ROW,
    CURRENT_SCHEMA,
    CURRENT_TIME,
    CURRENT_TIMESTAMP,
    CURRENT_TRANSFORM_GROUP_FOR_TYPE,
    CURRENT_USER,
    CURSOR,
    CYCLE,
    DATA,
    DATABASE,
    DATE,
    DATETIME,
    DAY,
    DEALLOCATE,
    DEC,
    DECADE,
    DECIMAL,
    DECLARE,
    DEFAULT,
    DELETE,
    DELIMITED,
    DELIMITER,
    DENSE_RANK,
    DEREF,
    DESC,
    DESCRIBE,
    DETERMINISTIC,
    DIRECTORY,
    DISCARD,
    DISCONNECT,
    DISTINCT,
    DISTRIBUTE,
    DIV,
    DO,
    DOUBLE,
    DOW,
    DOY,
    DROP,
    DUPLICATE,
    DYNAMIC,
    EACH,
    ELEMENT,
    ELSE,
    ENCODING,
    ENCRYPTION,
    END,
    END_FRAME,
    END_PARTITION,
    END_EXEC,
    ENDPOINT,
    ENGINE,
    ENUM,
    EPOCH,
    EQUALS,
    ERROR,
    ESCAPE,
    EVENT,
    EVERY,
    EXCEPT,
    EXCLUDE,
    EXEC,
    EXECUTE,
    EXISTS,
    EXP,
    EXPANSION,
    EXPLAIN,
    EXTENDED,
    EXTERNAL,
    EXTRACT,
    FAIL,
    FALSE,
    FETCH,
    FIELDS,
    FILE,
    FILES,
    FILE_FORMAT,
    FILTER,
    FIRST,
    FIRST_VALUE,
    FLOAT,
    FLOOR,
    FOLLOWING,
    FOR,
    FORCE,
    FORCE_NOT_NULL,
    FORCE_NULL,
    FORCE_QUOTE,
    FOREIGN,
    FORMAT,
    FORWARD,
    FRAME_ROW,
    FREE,
    FREEZE,
    FROM,
    FULL,
    FULLTEXT,
    FUNCTION,
    FUNCTIONS,
    FUSION,
    GENERATED,
    GET,
    GLOBAL,
    GRANT,
    GRANTED,
    GRAPHVIZ,
    GROUP,
    GROUPING,
    GROUPS,
    HASH,
    HAVING,
    HEADER,
    HIVEVAR,
    HOLD,
    HOUR,
    IDENTITY,
    IF,
    IGNORE,
    ILIKE,
    IMMUTABLE,
    IN,
    INCREMENT,
    INDEX,
    INDICATOR,
    INHERIT,
    INNER,
    INOUT,
    INPUTFORMAT,
    INSENSITIVE,
    INSERT,
    INT,
    INTEGER,
    INTERSECT,
    INTERSECTION,
    INTERVAL,
    INTO,
    IS,
    ISODOW,
    ISOLATION,
    ISOYEAR,
    JAR,
    JOIN,
    JSON,
    JSONFILE,
    JULIAN,
    KEY,
    KILL,
    LAG,
    LANGUAGE,
    LARGE,
    LAST,
    LAST_VALUE,
    LATERAL,
    LEAD,
    LEADING,
    LEFT,
    LEVEL,
    LIKE,
    LIKE_REGEX,
    LIMIT,
    LISTAGG,
    LN,
    LOCAL,
    LOCALTIME,
    LOCALTIMESTAMP,
    LOCATION,
    LOCKED,
    LOGIN,
    LOWER,
    MACRO,
    MANAGEDLOCATION,
    MATCH,
    MATCHED,
    MATERIALIZED,
    MAX,
    MAXVALUE,
    MEDIUMINT,
    MEMBER,
    MERGE,
    METADATA,
    METHOD,
    MICROSECOND,
    MICROSECONDS,
    MILLENIUM,
    MILLENNIUM,
    MILLISECOND,
    MILLISECONDS,
    MIN,
    MINUTE,
    MINVALUE,
    MOD,
    MODE,
    MODIFIES,
    MODULE,
    MONTH,
    MSCK,
    MULTISET,
    MUTATION,
    NANOSECOND,
    NANOSECONDS,
    NATIONAL,
    NATURAL,
    NCHAR,
    NCLOB,
    NEW,
    NEXT,
    NO,
    NOBYPASSRLS,
    NOCREATEDB,
    NOCREATEROLE,
    NOINHERIT,
    NOLOGIN,
    NONE,
    NOREPLICATION,
    NORMALIZE,
    NOSCAN,
    NOSUPERUSER,
    NOT,
    NOTHING,
    NOWAIT,
    NTH_VALUE,
    NTILE,
    NULL,
    NULLIF,
    NULLS,
    NUMERIC,
    NVARCHAR,
    OBJECT,
    OCCURRENCES_REGEX,
    OCTET_LENGTH,
    OCTETS,
    OF,
    OFFSET,
    OLD,
    ON,
    ONLY,
    OPEN,
    OPERATOR,
    OPTION,
    OPTIONS,
    OR,
    ORC,
    ORDER,
    OUT,
    OUTER,
    OUTPUTFORMAT,
    OVER,
    OVERFLOW,
    OVERLAPS,
    OVERLAY,
    OVERWRITE,
    OWNED,
    PARAMETER,
    PARQUET,
    PARTITION,
    PARTITIONED,
    PARTITIONS,
    PASSWORD,
    PATTERN,
    PERCENT,
    PERCENT_RANK,
    PERCENTILE_CONT,
    PERCENTILE_DISC,
    PERIOD,
    PIVOT,
    PLACING,
    PLANS,
    PORTION,
    POSITION,
    POSITION_REGEX,
    POWER,
    PRECEDES,
    PRECEDING,
    PRECISION,
    PREPARE,
    PRESERVE,
    PRIMARY,
    PRIOR,
    PRIVILEGES,
    PROCEDURE,
    PROGRAM,
    PURGE,
    QUALIFY,
    QUARTER,
    QUERY,
    QUOTE,
    RANGE,
    RANK,
    RCFILE,
    READ,
    READS,
    REAL,
    RECURSIVE,
    REF,
    REFERENCES,
    REFERENCING,
    REGCLASS,
    REGR_AVGX,
    REGR_AVGY,
    REGR_COUNT,
    REGR_INTERCEPT,
    REGR_R2,
    REGR_SLOPE,
    REGR_SXX,
    REGR_SXY,
    REGR_SYY,
    RELATIVE,
    RELEASE,
    RENAME,
    REPAIR,
    REPEATABLE,
    REPLACE,
    REPLICATION,
    RESTRICT,
    RESULT,
    RETURN,
    RETURNING,
    RETURNS,
    REVOKE,
    RIGHT,
    ROLE,
    ROLLBACK,
    ROLLUP,
    ROW,
    ROW_NUMBER,
    ROWID,
    ROWS,
    SAFE_CAST,
    SAVEPOINT,
    SCHEMA,
    SCOPE,
    SCROLL,
    SEARCH,
    SECOND,
    SELECT,
    SEMI,
    SENSITIVE,
    SEQUENCE,
    SEQUENCEFILE,
    SEQUENCES,
    SERDE,
    SERIALIZABLE,
    SESSION,
    SESSION_USER,
    SET,
    SETS,
    SHARE,
    SHOW,
    SIMILAR,
    SKIP,
    SMALLINT,
    SNAPSHOT,
    SOME,
    SORT,
    SPATIAL,
    SPECIFIC,
    SPECIFICTYPE,
    SQL,
    SQLEXCEPTION,
    SQLSTATE,
    SQLWARNING,
    SQRT,
    STABLE,
    STAGE,
    START,
    STATIC,
    STATISTICS,
    STDDEV_POP,
    STDDEV_SAMP,
    STDIN,
    STDOUT,
    STORAGE_INTEGRATION,
    STORED,
    STRICT,
    STRING,
    SUBMULTISET,
    SUBSTRING,
    SUBSTRING_REGEX,
    SUCCEEDS,
    SUM,
    SUPER,
    SUPERUSER,
    SWAP,
    SYMMETRIC,
    SYNC,
    SYSTEM,
    SYSTEM_TIME,
    SYSTEM_USER,
    TABLE,
    TABLES,
    TABLESAMPLE,
    TBLPROPERTIES,
    TEMP,
    TEMPORARY,
    TEXT,
    TEXTFILE,
    THEN,
    TIES,
    TIME,
    TIMESTAMP,
    TIMESTAMPTZ,
    TIMETZ,
    TIMEZONE,
    TIMEZONE_HOUR,
    TIMEZONE_MINUTE,
    TINYINT,
    TO,
    TOP,
    TRAILING,
    TRANSACTION,
    TRANSIENT,
    TRANSLATE,
    TRANSLATE_REGEX,
    TRANSLATION,
    TREAT,
    TRIGGER,
    TRIM,
    TRIM_ARRAY,
    TRUE,
    TRUNCATE,
    TRY_CAST,
    TYPE,
    UESCAPE,
    UNBOUNDED,
    UNCACHE,
    UNCOMMITTED,
    UNION,
    UNIQUE,
    UNKNOWN,
    UNLOGGED,
    UNNEST,
    UNSIGNED,
    UNTIL,
    UPDATE,
    UPPER,
    URL,
    USAGE,
    USE,
    USER,
    USING,
    UUID,
    VALID,
    VALIDATION_MODE,
    VALUE,
    VALUE_OF,
    VALUES,
    VAR_POP,
    VAR_SAMP,
    VARBINARY,
    VARCHAR,
    VARIABLES,
    VARYING,
    VERBOSE,
    VERSIONING,
    VIEW,
    VIRTUAL,
    VOLATILE,
    WEEK,
    WHEN,
    WHENEVER,
    WHERE,
    WIDTH_BUCKET,
    WINDOW,
    WITH,
    WITHIN,
    WITHOUT,
    WORK,
    WRITE,
    XOR,
    YEAR,
    ZONE,

    undefined,
}